using APesquisa.Data.Models;
using APesquisa.Models;
using APesquisa.Models.Enum;
using APesquisa.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APesquisa.Service
{
    public class FormulaAnalysisService : IFormulaAnalysisService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FormulaAnalysisService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public FormulaAnalysisResult GetFormulaAnalysisResult(string components)
        {
            var withouStarts = components.Replace("*", string.Empty);
            var componentsWithObservationsAsComponent = AbstractComponentsObservations(withouStarts);
            var componentsWithTypes = GetComponentWithTypes(componentsWithObservationsAsComponent);
            return GetFormularAnalysisResult(components, componentsWithTypes);
        }

        private FormulaAnalysisResult GetFormularAnalysisResult(string originalComponents, IEnumerable<ComponentData> componentsWithTypes)
        {
            return new FormulaAnalysisResult()
            {
                ComponentsData = componentsWithTypes,
                OriginalFormula = originalComponents,
                Type = GetFormulaType(componentsWithTypes)
            };
        }

        private IEnumerable<ComponentData> GetComponentWithTypes(string componentsWithObservationsAsComponent)
        {
            var splittedComponents =
                componentsWithObservationsAsComponent
                .Split(new string[] { ",", ";", "|", "/", "(and)", ".", ":", "\n" }, StringSplitOptions.None)
                .Where(c => !String.IsNullOrEmpty(c.Trim()))
                .Select(c => c.Trim());

            var storedComponents = _unitOfWork.Component.Get().Select(c => new Component()
            {
                Name = c.Name.ClearToCompare(),
                Type = c.Type,
                AllowedLowPoo = c.AllowedLowPoo,
                AllowedNoPoo = c.AllowedNoPoo
            });

            return GetComponentDatas(splittedComponents, storedComponents);
        }

        private IEnumerable<ComponentData> GetComponentDatas(IEnumerable<string> splittedComponents, IEnumerable<Component> storedComponents)
        {
            var list = new List<ComponentData>();

            foreach (var component in splittedComponents)
            {
                var clearComponentName = component.ClearToCompare();
                var storedComponentMatch = storedComponents.FirstOrDefault(s => s.Name == clearComponentName);

                list.Add(new ComponentData()
                {
                    Name = component,
                    PooType = GetComponentPooType(storedComponentMatch),
                    ComponentType = storedComponentMatch?.Type ?? "Comum"
                });
            }

            return list;
        }

        private ComponentPooType GetComponentPooType(Component component)
        {
            if (component == null)
                return ComponentPooType.Unknown;
            if (component.AllowedLowPoo == false)
                return ComponentPooType.ForbiddenBoth;
            if (component.AllowedLowPoo == true && component.AllowedNoPoo == false)
                return ComponentPooType.AllowedLowPooForbidenNoPoo;

            return ComponentPooType.AllowedBoth;
        }

        private PooType GetFormulaType(IEnumerable<ComponentData> componentsWithTypes)
        {
            if (componentsWithTypes.Any(a => a.PooType == ComponentPooType.ForbiddenBoth))
                return PooType.Forbidden;
            if (componentsWithTypes.Any(a => a.PooType == ComponentPooType.AllowedLowPooForbidenNoPoo))
                return PooType.AllowedForLowPoo;

            return PooType.AllowedForBoth;
        }

        private string AbstractComponentsObservations(string components)
        {
            var componentsObservations = components.Split('(', ')').Where((c, i) => i % 2 != 0 && c != "and");
            var componentsWithoutObservationsBeetweenRelatives = RemoveComponents(components, componentsObservations);
            var abstractedObservations = componentsWithoutObservationsBeetweenRelatives + AddObservationsAsComponent(componentsObservations);

            return abstractedObservations;
        }

        private string AddObservationsAsComponent(IEnumerable<string> componentsObservations)
        {
            StringBuilder observations = new StringBuilder();
            foreach (var componentObservations in componentsObservations)
                observations.Append("," + componentObservations);

            return observations.ToString();
        }

        private string RemoveComponents(string components, IEnumerable<string> componentsBetweenRelatives)
        {
            foreach (var componentBetweenRelatives in componentsBetweenRelatives)
                components = components.Replace("(" + componentBetweenRelatives + ")", string.Empty);

            return components;
        }

        public IEnumerable<Component> GetComponentByPartialText(string searchText)
        {
            return _unitOfWork.Component.Get();
        }
    }
}