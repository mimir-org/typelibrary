import { XCircle } from "@styled-icons/heroicons-outline";
import { useTranslation } from "react-i18next";
import { useTheme } from "styled-components";
import { Token } from "../../../../complib/general";
import { Flexbox, MotionFlexbox } from "../../../../complib/layouts";
import { MotionText } from "../../../../complib/text";
import { useDebounceState } from "../../../../hooks/useDebounceState";
import { SearchField } from "../../../common/SearchField";
import { ExploreSection } from "../ExploreSection";
import { FilterMenu } from "./components/filter/FilterMenu";
import { ItemList } from "./components/item/ItemList";
import { NodeSearchItem } from "./components/node/NodeSearchItem";
import { SearchPlaceholder } from "./components/SearchPlaceholder";
import { useFilterState, useGetFilterGroups, useSearchResults } from "./Search.helpers";

interface SearchProps {
  selected?: string;
  setSelected: (item: string) => void;
}

/**
 * Component which displays search controls and search results.
 *
 * @param selected the id of the search result which has been selected
 * @param setSelected sets the id of the selected search result item
 * @constructor
 */
export const Search = ({ selected, setSelected }: SearchProps) => {
  const theme = useTheme();
  const { t } = useTranslation("translation", { keyPrefix: "search" });
  const filterGroups = useGetFilterGroups();
  const [activeFilters, toggleFilter] = useFilterState([]);
  const [query, setQuery, debouncedQuery] = useDebounceState("");
  const [results, isLoading] = useSearchResults(debouncedQuery, activeFilters);

  const showResults = results.length > 0;
  const showFilterTokens = activeFilters.length > 0;
  const showSearchText = !isLoading;
  const showPlaceholder = !isLoading && results.length === 0;

  return (
    <ExploreSection title={t("title")}>
      <Flexbox gap={theme.tyle.spacing.xxxl} alignItems={"center"}>
        <SearchField value={query} onChange={(e) => setQuery(e.target.value)} placeholder={t("placeholders.search")} />
        <FilterMenu
          name={t("filter.title")}
          filterGroups={filterGroups}
          activeFilters={activeFilters}
          toggleFilter={toggleFilter}
        />
      </Flexbox>

      {showFilterTokens && (
        <MotionFlexbox layout={"position"} flexWrap={"wrap"} gap={theme.tyle.spacing.base}>
          {activeFilters.map((x, i) => (
            <Token
              key={i}
              actionable
              actionText={t("filter.templates.remove", { object: x.label })}
              actionIcon={<XCircle />}
              onAction={() => toggleFilter(x)}
            >
              {x.label}
            </Token>
          ))}
        </MotionFlexbox>
      )}

      {showSearchText && (
        <MotionText
          layout
          variant={"label-large"}
          color={theme.tyle.color.sys.surface.variant.on}
          {...theme.tyle.animation.fade}
        >
          {t("templates.hits", { amount: results.length })}
        </MotionText>
      )}

      {showResults && (
        <ItemList>
          {results.map((nodeItem) => (
            <NodeSearchItem
              key={nodeItem.id}
              isSelected={nodeItem.id === selected}
              setSelected={() => setSelected(nodeItem.id)}
              {...nodeItem}
            />
          ))}
        </ItemList>
      )}

      {showPlaceholder && (
        <SearchPlaceholder
          title={t("help.templates.query", { query })}
          subtitle={t("help.subtitle")}
          tips={[t("help.tip1"), t("help.tip2"), t("help.tip3")]}
        />
      )}
    </ExploreSection>
  );
};
